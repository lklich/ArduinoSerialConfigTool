#include <Thread.h>
#include <EEPROM.h>

#define RF 5     // Odbiornik RF
#define LED 7     // Odbiornik RF
#define PHOTO 1  // Fotorezystor
#define RELAY 3  // Przekaźnik
#define PIR 2    // PIR

#define IDNT 30021       // Znacznik urządzenia
#define VER 1.2          // Wersja firmware
byte debug = false;      // Czy tryb debugowania? Informacje w monitorze portu. 

volatile byte ruch = LOW;          // Czy wykryto ruch?
volatile byte dzien = LOW;         // Czy jest dzień?
volatile byte wlacz = LOW;         // Czy światło jest aktualnie włączone?
unsigned histereza = 10;           // histereza przałączania dzień/noc
volatile unsigned int tik = 1;     // Odliczany czas włączenia światła
volatile unsigned int czas = 0;    // Domyślny czas włączenia światła
volatile unsigned int swiatlo = 0; // Odczyt z fotorezystora
bool rfClick = false;              // Czy wciśnięty przycisk A w pilocie?
bool PERMANENTBUTTON = LOW;        // Stan przycisku pilota - włącza światło na stałe
unsigned int minswiatlo = 90;      // Wartość światła przełączana dzień/noc

const byte numChars = 32;
char receivedChars[numChars];
char tempChars[numChars];     
boolean newData = false;      
char commandPC[numChars] = {0};
int valuePC = 0;

Thread pseudoTh = Thread();
 
void setup(){
  Serial.begin(9600);   
  initEprom();
  pinMode(PIR, INPUT);   
  pinMode(RELAY, OUTPUT);
  pinMode(PHOTO, INPUT);
  pinMode(LED, OUTPUT);
  pinMode(RF, INPUT);
  digitalWrite(RELAY,HIGH); 
  digitalWrite(LED,LOW); 
  attachInterrupt(digitalPinToInterrupt(PIR),setAlarm,RISING);

  pseudoTh.onRun(incTik);
  pseudoTh.setInterval(1000);   
}

void initEprom(){
 if(EEPROM.read(0) == 255) EEPROM.write(0,15);  // czas włączenia światła = 15 sekund
 if(EEPROM.read(1) == 255) EEPROM.write(1,170); // światło przejścia dzień/noc = 170
 if(EEPROM.read(2) == 255) EEPROM.write(2,0);   // debuger domyślnie na 0
 if(EEPROM.read(3) == 255) EEPROM.write(3,10);  // histereza domyślnie na 10
  czas = EEPROM.read(0);
  minswiatlo = EEPROM.read(1);
  debug = EEPROM.read(2);
  histereza = EEPROM.read(3);
}

void setAlarm(){
  ruch = HIGH;
}

void runDebug(String co){
 Serial.println(co);
 Serial.print(F("move = ")); Serial.println(String(ruch));
 Serial.print(F("tik = ")); Serial.print(tik); Serial.print(F(" z ")); Serial.println(czas);
 Serial.print("light = "); Serial.print(swiatlo); Serial.print(" level = "); Serial.print(minswiatlo); Serial.print(" his = "); Serial.println(histereza);
 Serial.print("permenant = "); Serial.println(PERMANENTBUTTON);
 Serial.print("clicked = "); Serial.println(rfClick);
 Serial.print("day = "); if(dzien) Serial.println("yes"); else Serial.println("no");
 Serial.println(F("OK"));
}

void disLight(){
 digitalWrite(RELAY,HIGH);
 digitalWrite(LED,LOW);
 PERMANENTBUTTON = LOW; 
 wlacz = LOW;
  if (debug) runDebug("OFF");
 delay(200);
}

void enLight(){
 digitalWrite(RELAY,LOW); 
 wlacz = HIGH;
 if (debug) runDebug("ON");
 delay(200);
}

void incTik(){
  swiatlo = analogRead(PHOTO); 
    if(swiatlo > minswiatlo+histereza) { 
      dzien = HIGH; 
      PERMANENTBUTTON = LOW; 
      } else 
      if(swiatlo < minswiatlo-histereza) 
        dzien = LOW;   
  
  if((!PERMANENTBUTTON) && (!dzien)) tik++;
  if (tik > czas) {
    if (wlacz) disLight();
    tik = 1;
  }  
}

// Funkcja resetująca Arduino
void(* resetFunc) (void) = 0;

String decodeComm(){
  if(String(commandPC) == "ABO" && valuePC == 0) Serial.println("Leszek Klich 2019"); else
  if(String(commandPC) == "VER" && valuePC == 0) Serial.println(VER); else
  if(String(commandPC) == "IDE" && valuePC == 0) Serial.println(IDNT); else
  if(String(commandPC) == "HIS" && valuePC == 0) Serial.println(histereza); else
  if(String(commandPC) == "TIM" && valuePC == 0) Serial.println(czas); else
  if(String(commandPC) == "LIG" && valuePC == 0) Serial.println(swiatlo); else
  if(String(commandPC) == "DAY" && valuePC == 0) Serial.println(dzien); else
  if(String(commandPC) == "LEV" && valuePC == 0) Serial.println(minswiatlo); else
  if(String(commandPC) == "REL" && valuePC == 0) Serial.println(wlacz); else
  if(String(commandPC) == "DEB" && valuePC == 0) Serial.println(debug); else
  if(String(commandPC) == "MOV" && valuePC == 0) Serial.println(ruch); 
  else
  if(String(commandPC) == "RES" && valuePC == 0) resetFunc(); else
  if(String(commandPC) == "PAR" && valuePC == 0) { Serial.print("S:"); Serial.print(czas); Serial.print(" T:"); Serial.println(minswiatlo); Serial.print(" H:"); Serial.println(histereza); } else
  if(String(commandPC) == "TIM" && valuePC > 0 && valuePC < 255) { EEPROM.write(0, valuePC); initEprom(); } else // czas
  if(String(commandPC) == "LEV" && valuePC > 0 && valuePC < 255) { EEPROM.write(1, valuePC); initEprom(); } else // minimalny poziom światła do przełączania trybu  dzien/noc
  if(String(commandPC) == "DEB" && valuePC == 0 && valuePC == 1) { EEPROM.write(2, valuePC); initEprom(); } else // tryb debugowania
  if(String(commandPC) == "HIS" && valuePC > 0 && valuePC < 200) { EEPROM.write(3, valuePC); initEprom(); } else // histereza
  if(String(commandPC) == "DEF" && valuePC == 0) { EEPROM.write(0,15); EEPROM.write(1,170); EEPROM.write(2,0); EEPROM.write(3,10); initEprom(); } else // reset do domyślnych ustawień
  Serial.println("ERR");
  //resetFunc();
}

// Dzieli przychodzące z portu PC dane na komendę oraz wartość
void parseData() {     
    char *strIndex; 
    valuePC = 0;
    strcpy(commandPC, "0");
    strIndex = strtok(tempChars,":");      // Pobierz pierwszą wartość
    strcpy(commandPC, strIndex); 
 
    strIndex = strtok(NULL, ":"); // this continues where the previous call left off
    valuePC = atoi(strIndex);     // konwersja do integer
    if (valuePC > 255) valuePC = 0;
    //strIndex = strtok(NULL, ":");     // Jeśli kolejne parametry
    //floatFromPC = atof(strIndex);     // Można także do float...
}

void receivePort() {
    static boolean inProgress = false;
    static byte index = 0;
    char fromChar = '[';
    char toChar = ']';
    char getting;

    while (Serial.available() > 0 && newData == false) {
        getting = Serial.read();

        if (inProgress == true) {
            if (getting != toChar) {
                receivedChars[index] = getting;
                index++;
                if (index >= numChars) {
                    index = numChars - 1;
                }
            }
            else {
                receivedChars[index] = '\0'; 
                inProgress = false;
                index = 0;
                newData = true;
            }
        }

        else if (getting == fromChar) {
            inProgress = true;
        }
    }
}


void loop(){
  ruch = digitalRead(PIR);    
  rfClick = digitalRead(RF);
 
  if(rfClick) {
    if(PERMANENTBUTTON == LOW) {
     PERMANENTBUTTON = HIGH; 
     digitalWrite(LED,HIGH);
     if (!wlacz) enLight(); 
     } else {
     if (wlacz) disLight();
    }
    delay(1000); // Opóźnienie ponownego przyciśnięcia
  }
 
   if (dzien) {
     tik = czas - 2000;
   } 

   if ((!dzien) && (ruch)) { 
       tik = 1; 
       if (!wlacz) enLight();
   }
   
  if (pseudoTh.shouldRun()) 
     pseudoTh.run();

    receivePort();
    
    if (newData == true) {
        strcpy(tempChars, receivedChars);
        parseData();
        newData = false;
        decodeComm();
    }
}

# ArduinoSerialConfigTool
Arduino serial get and set parameters
Kompletny przykład konfiguracji parametrów Arduino zapisywanych w EEPROM przy pomocy c#.

Program dla Arduino
Jest to urządzenie sterujące oświetleniem za pomocą czujnika zmierzchu oraz pilota.

Założenia:
1. Włączenie światła następuje po wykryciu ruchu tylko gdy jest ciemno i wyłącza po określonym czasie.
2. Jeśli włączono światło za pomocą pilota, zaświeca się na obudowie diona LED i urzadzenie nie reaguje na czujnik ruchu. Światło świeci się aż do świtu.
3. Parametry urządzenia (poziom światła, histereza, czas włączenia światła) można zmieniać za pomocą przewodu USB przez wirtualny port COM przy pomocy aplikacji GUI.
4. Aplikacja GUI posiada opcję analizatora, który na bieżąco pokazuje parametry odczytane z urządzenia. Dzieki temu można dobrać odpowiednie parametry.

Podzespoły:
1. Arduino Nano 5V
2. Czujnik ruchu HC-SR501
3. Fotorezystor GL5516-5K-10K
4. Moduł przekaźnika z optoizolacją
5. Moduł pilot/odbiornik SC2272 YK04
5. Miniaturowa przetwornica STEP-DOWN 230V na 5V typ H6B4
6. Dioda LED + rezystor 330om
7. Obudowa Z68U

W projekcie znajdują się kompletne źródła C# (Winforms) oraz szkic dla Arduino.

Lista parametrów urządzenia (wysyłane przez port COM z komputera - szybkość:9600)<br/>
[VER] - aktualna wersja firmware w urządzeniu<br/>
[IDE] - zwraca identyfikator zdefinowany jako IDNT. Słuzy do identyfikacji urządzenia<br/>
[HIS] - zwraca wartość histerezy <br/>
[TIM] - zwraca czas, na jaki włacza się światło po wykryciu ruchu<br/>
[LIG] - zwraca 1 gdy jest włączone światło oraz 0, gdy wyłączone<br/>
[DAY] - zwraca 1 gdy urządzenie jest w trybie dzień lub 0, gdy noc<br/>
[LEV] - zwraca wartość, która decyduje czy jest dzień czy noc (tę wartośc należy dobrać)<br/>
[REL] - zwraca czy przekaźnik jest włączony 1- włączony, 0 - wyłączone<br/>
[DEB] - zwraca informajcę czy włączony jest tryb debugowania. Jeśli 1-tak, 0-nie<br/>
[MOV] - zwraca 1 gdy wykryto ruch oraz 0 gdy brak ruchu z PIR<br/>
[RES] - resetuje urządzenie<br/>
[PAR] - wyświwetla w terminalu wszystkie parametry z EEPROM<br/>
[TIM:X] - ustawia czas włączenia świata w sekundach, gdzie X - ilość sekund (1-254)<br/>
[LEV:x] - ustawia wartość przełaczania trybu dzień/noc, gdzie X - wartość (1-254)<br/>
[DEB:X] - włącza lub wyłącza tryb debugowania<br/>
[HIS:X] - ustawia poziom histerezy dla identyfikacji dzień/noc, gdzie x z zakresu 1-199<br/>
[DEF:0] - ustawia parametry domyślne: czas:15 sekund, poziom przłączania170 (dla tego typu fotorezystora), debug:0, histereza:10<br/>


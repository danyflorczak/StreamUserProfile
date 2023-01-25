## Tutaj bedzie info co zrobione a co trzeba zrobic  
- Trzeba stworzyć klasy reprezetujace profil gracza i dane gry, a następnie użyć API Steam do wypełnienia tych klas odpowiednimi informacjami.</br>
- Aby importować i eksportować dane do i z pliku JSON, można użyć popularnej biblioteki C#, takiej jak Newtonsoft.Json, która obsługuje konwersję danych do i z JSON.</br>
- Aby importować i eksportować dane z bazy danych, możesz użyć biblioteki C#, takiej jak ADO.NET lub Entity Framework, aby połączyć się z bazą danych i użyć poleceń SQL do pobierania i przechowywania danych. </br>
- Jesli to ma być dla jednego profilu który masz z góry wyznaczony to jest mniejszy problem bo wystarczy ze podmienisz steamId (to powinienes miec na profilu steama) i apiKey(to sie pewnie jakos generuje czy cos) a jak masz miec mozliwosc ze uzytkownik ma podac swoj steam id i na podstawie tego ma sie wykonac reszta to trzeba sie bawic w jakies intefejsy i robic web apke albo konsolowa w zaleznosci co tam wam wykladowca powiedzial.
- Aby importować i eksportować dane z pliku XML, można użyć wbudowanych klas C#, takich jak XmlSerializer i XmlReader/XmlWriter, do odczytu i zapisu danych do pliku.</br>


## DONE
- [x] Wysyłanie requestu do Steam Api
- [x] Parsowanie danych takich jak nazwa gry, czas spedzony w grze (moze byc zmieniony na ten z ostatnich 2 tygodni)
- [x] Wyswietlanie nazwy gry i appid potrzebne do drugiego requestu do api

## TO DO's

- [ ] Zabawa z bazami danych i phpem jak dobrze rozumiem z tego co pisales julce
- [ ] dokonczenie GetGameDetails zeby pobieralo kategorie, required age itp.
- [ ] Stworzenie interfejsu jesli tak jest w specyfikacji
- [ ] pobieranie od uzytkownika steam_id jesli tak jest w specyfikacji

## QA
- Czy mamy gdzies wyswietlac UserProfile z danymi ktore znalezlismy czy tak jak bylo napisane po prostu stworzyc jakis endpoint ktory bedzie to udostepnial? </br>
- Czy masz robic web apke z interfejsem czy to moze byc apka konsolowa ? </br>
- Czy wiesz gdzie ty masz exportowac pliki xml i wgl gdzie to ma byc i jako co bo zakladam ze chcemy gdzies exportowac ten UserProfile ktory tworzymy </br>
- Ile masz na to czasu ?


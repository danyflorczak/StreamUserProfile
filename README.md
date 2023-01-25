Tutaj bedzie info co zrobione a co trzeba zrobic  </br>
1.Trzeba stworzyć klasy reprezetujace profil gracza i dane gry, a następnie użyć API Steam do wypełnienia tych klas odpowiednimi informacjami.
Aby importować i eksportować dane z pliku XML, można użyć wbudowanych klas C#, takich jak XmlSerializer i XmlReader/XmlWriter, do odczytu i zapisu danych do pliku.</br>
2.Aby importować i eksportować dane do i z pliku JSON, można użyć popularnej biblioteki C#, takiej jak Newtonsoft.Json, która obsługuje konwersję danych do i z JSON.</br>
3.Aby importować i eksportować dane z bazy danych, możesz użyć biblioteki C#, takiej jak ADO.NET lub Entity Framework, aby połączyć się z bazą danych i użyć poleceń SQL do pobierania i przechowywania danych. </br>
4.Jesli to ma być dla jednego profilu który masz z góry wyznaczony to jest mniejszy problem bo wystarczy ze podmienisz steamId (to powinienes miec na profilu steama) i apiKey(to sie pewnie jakos generuje czy cos) a jak masz miec mozliwosc ze uzytkownik ma podac swoj steam id i na podstawie tego ma sie wykonac reszta to trzeba sie bawic w jakies intefejsy i robic web apke albo konsolowa w zaleznosci co tam wam wykladowca powiedzial.


# Melkor

Web aplikacija pomoću koje se može vršiti provjera određenih kodova tj. zadaća. Aplikacija pomoću github link-a skida projekta, kompajlira ga i testira, ako su definirani testovi za taj projekt. 

#### URL: <a href="http://melkor-core.azurewebsites.net">Project link</a>

#### Svaka razina je zasebno ostvarena: ####

_Skidanje projekta:_
>Aplikacija skida projekt sa git-a. U svrhu preuzimanja koristimo klasu WebClient kojoj predajemo url projekta. Projekt se tada preuzima u .zip formatu. Nakon čega ga raspakiravamo u zasebnu datoteku za svakog korisnika(root_datoteka\guid_korisnika).

_Kompajliranje(build):_
>Nakon skidanja prolazi se kroz sve datoteke, te se svaki projekt zasebno kompajlira. Kompajliranje se vrši uz pomoć .NET framework-a...

_Testiranje:_
>Testiranje je definirano samo za neke projekte. U trenutnoj fazi aplikacije, testiraju se samo .dll datotetke. Kod testiranja prvo se pokreće klasa TestPicker kojom se odabiru definirani testovi za taj projekt. Ta klasa tada instancira nove klase ovisno o zadaći(TesterH2T1, testira zadaću(homework) 2 i zadatak(task) 1). U tim klasama se učitava assembly .dll datoteka iz zadaće, te se nad njima provode testovi. U samoj metodi testa se stvaraju nove instance klasa definiranih u učitanim .dll datotekama, te se pozivaju metode definirane unutar njih. Pozivanjem metoda se također utvrđuje njihov ispravan rad. Prolazak testa se kasnji prikazuje na web stranici(više o tome u nastavku).

### OPIS KORIŠTENJA WEB STRANICE: ###

_Home(Melkor) stranica:_
>Na početnoj stranici se vide trenutne obavijesti, koje postavlja admin stranice. Obavijesti se uzimaju iz baze, te se najaktualnije prikazuju korisniku.
![Alt text](/Screenshots/homeScreen.png?raw=true)

_Start test:_
>Stranica služi za unos github url-a, na njoj se nalazi jednostavna forma pomoću koje se vrši unos. Pritiskom na gumb "Start" pokreće se skidanje projekta, te se dogodi prijelaz na sljedeću stranicu(Build).Za pristup stranici korisnik mora biti prijavljen.
![Alt text](/Screenshots/test%20screen.png?raw=true)

_Build:_
>Na njoj se prikazuju zadaci koji su bili kompajlirani unutar projekta. Klikom na zadatak za koji su definirani testovi(pored oznake Build ima također oznaku Tests),prikazuju se koji su prošli a koji nisu. Sam proces kompajliranja i testiranja se vrši u pozadini te stranice.
![Alt text](/Screenshots/build%20screen.png?raw=true)

_Admin:_
>Admin ima mogućnost dodavanja novih obavijesti na stranicu, unosom naslova i teksta obavijseti. Ta obavijest se tada sprema u bazu obavijesti. Također se prikazuju adminu dva stupca testova, jedan stupac testovi koji su prošli, a drugi koji nisu prošli. Za sad još nije implementirano da prikazuje koji korisnik je pokrenuo koji test, nego ih samo prikazuje. To će biti dodano u bližoj budućnosti. 
![Alt text](/Screenshots/admin%20screen.png)

### Podjela zadatka:###

* Alen Štruklec
 * Izrada kompletnog dizajna
 * Modul za kompajliranje skinutog git projekta
  
* Zvonimir Kučiš
 * Modul za skidanje git projekta
 * Modul za testiranje zadataka
  
* ZajedničKi rad
 * Baza podataka

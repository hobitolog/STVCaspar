# STVCaspar

SpacjaTV CasparCG project.

![CasparCG Client](https://github.com/hobitolog/STVCaspar/blob/master/CasparCG%20Client.png)

## Serwer CasparCG

Do działania aplikacji klienckiej potrzebujemy zainstalowanej aplikacji serwerowej na komputerze docelowym o wydajnej karcie graficznej.
Klient obsługuje do 8 kanałów. Ich ilość i rodzaj określamy przez edycję pliku serwera casparcg.config. W celu użycia template należy skopiować zawartość folderu Server templates z repozytorium do folderu templates w katalogu serwera.

## Uruchamianie

Po sukcesywnym uruchomieniu serwera, czas na uruchomienie aplikacji klienckiej. Po otworzeniu aplikacji mamy możliwość połączenia się z serwerem. Jeśli obie aplikacje znajdują się na tym samym komputerze, to w polu adresu zostawiamy "localhost", w innym wypadku należy wpisać odpowiedni adres IP serwera.

## Działanie

Aplikacja kliencka podzielona jest na odpowiednie zakładki:
* Video - po połączeniu otrzymujemy listę plików wideo znajdujących się w katalogu serwera, po wybraniu pliku i zaznaczeniu checkboxa klip zostaje załadowany na odpowiedni kanał. Jeśli chcemy dokonać zmian wystarczy odznaczyć checkboxa, co spowoduje usunięcie załadowanego pliku z kanału.
* InfoBar - do naszej dyspozycji dostajemy 2 pola tekstowe dla paska informacji, oraz paska autora. Po wpisaniu wybranych tekstów zaznaczamy checkbox wybranego kanału w celu załadowania paska.
* Clock - zaznaczenie checkboxa spowoduje załadowanie zegara na danym kanale.
* Logo - zaznaczenie checkboxa spowoduje załadowanie loga SpacjiTV na danym kanale.

Po wybraniu pożądanych opcji wystarczy odtworzyć transmisję na kanałach poprzez wciśnięcie przycisku Start. Klient odtworzy tylko te kanały na których załadowany został plik wideo. Transmisję można także spauzować, bądź zatrzymać co powoduje usunięcie wszystkich załadowanych opcji z kanałów.

Po zakończonej pracy wystarczy zamknąć program, lub wcisnąć przycisk disconnect, jeśli chcemy zacząć sterować innym serwerem.

## Napisane przy pomocy

* Visual Studio 2017 - kod programu
* Animate CC 2018 Trial + [Template Generator](https://sourceforge.net/projects/casparcg/files/CasparCG_Template_Generator/) - template flash

* Jeśli chcesz stworzyć własny template flash polecam ten poradnik, sam z niego korzystałem:
[![poradnik](https://img.youtube.com/vi/mn4IfcDkIhU/0.jpg)](https://www.youtube.com/watch?v=mn4IfcDkIhU)

## Autor

* Kacper Cieślewicz - [Kacper Cieślewicz](https://github.com/KacperCieslewicz)

## Podziękowania

* Forum CasparCG - [CasparCG Forum](https://casparcgforum.org)

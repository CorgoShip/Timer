Zadání aplikace ve WPF bude znít takto.
Chceme udělat jednoduchou aplikaci zajišťující odpočet startu lodí při závodu
- Na úvod potřebujeme řídící dialog, který zjistí, zda startovací procedura je 5, 3 nebo 1 minuta (řekněme radiobuttony, předvolených je 5 minut)
- Po stisku tlačítka „Zahájit odpočet“ se zobrazí digitálně vykreslený panel tří sedmisegmentových číslic (klasická číslice digitálního budíku - https://cs.wikipedia.org/wiki/Sedmisegmentovka, hezky vykreslené např. zde https://fi.wikipedia.org/wiki/Tiedosto:7_Segment_Display_with_Labeled_Segments.svg)
- Na uvedených třech segmentech bude první číslice zobrazovat počet minut do startu a další dvě číslice počet sekund do startu z aktuálně odpočítávané minuty (v poslední minutě už tedy bude svítit jen poslední dvě, příp. poslední displej)
- Úvodní nuly se zobrazovat nebudou, pouze samotná 0 na konci odpočítávání.
- První číslice s minutami se bude vykreslovat jasně červeně
- Odpočítávané číslice sekund se budou vykreslovat jasně zeleně, posledních 10 sekund (10…1) pak jasně žlutě
- Samotná 0 na konci odpočítávání na poslední pozici se vykreslí červeně
- Odpočet bude vázán na hodiny reálného času (timer) počítače
- Pokud dokážete používat zvukový výstup, pak zobrazení každé žluté číslice bude provázeno krátkým tiknutím, zobrazení 0 na konci každé minuty bude provázeno delším zvukem a poslední červená nula dlouhým hvizdem

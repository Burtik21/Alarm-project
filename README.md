# Alarm project
V https://github.com/Burtik21/Alarm-project/releases/tag/v1.0 je ke stáhnutí .apk soubor -> jestli nebude fungovat, lze vyzkoušet i .exe soubor na windows.

Funkčnost aplikace se dá ověřit na endpointech (změna v jsonu):
 - Po zadání času lze vidět změnu na: http://141.147.16.43/api/cas/
 - Po zadání vyonutí/zapnutí lze vidět změnu na: http://141.147.16.43/api/is_on/
 - Po zadaní hlasitosti lze vidět změnu na: http://141.147.16.43/api/volume/
 - Historie budíků se volá z http://141.147.16.43/api/alarm_duration_history/ -> také lze vidět json s historií

## Logika
Pomocí aplikace lze nastavit vlastnosti budíku (c++ kod pro fyzický alarm zde: https://github.com/Burtik21/LAZY-ALARM/tree/main/Alarm )

## Back - End
(https://github.com/Burtik21/LAZY-ALARM/tree/main/back%20-%20end)

Používám Linux server ( distribuce Ubuntu ) který hostuje Oracle ( zdarma samozřejmě ) 

Je to NGINX webový server 

Endpointy obsluhuje Python Flask 

  

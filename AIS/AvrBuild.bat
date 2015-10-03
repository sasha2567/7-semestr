@ECHO OFF
"C:\Program Files (x86)\Atmel\AVR Tools\AvrAssembler2\avrasm2.exe" -S "E:\AIS\labels.tmp" -fI -W+ie -C V0E -o "E:\AIS\lab1.hex" -d "E:\AIS\lab1.obj" -e "E:\AIS\lab1.eep" -m "E:\AIS\lab1.map" "E:\AIS\main.asm"

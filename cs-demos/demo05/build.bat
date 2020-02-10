del *.exe
del *.dll

csc  math.cs -out:utils.dll -t:library

csc factorial-app.cs -r:utils.dll -out:factapp.exe

factapp
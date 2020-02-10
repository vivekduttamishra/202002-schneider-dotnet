@echo off

del *.exe
del *.dll

csc -out:fapp.exe app01.cs  data.cs furnitures.cs

fapp
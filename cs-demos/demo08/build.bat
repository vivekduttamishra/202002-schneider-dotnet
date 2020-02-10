@echo off

del *.exe
del *.dll

csc -t:library -out:schneider-data.dll schneider-data.cs
csc -t:library -out:data.dll data.cs
csc -t:library -out:furnitures.dll furnitures.cs

csc -out:fapp.exe app.cs -r:data.dll,furnitures.dll,schneider-data.dll

fapp
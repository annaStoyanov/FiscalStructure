dotnet publish ../../NigeriaFiscalization/NigeriaFiscalization.sln -o ../../NigeriaFiscalization/publish

rm -rf Plugins/Nigeria/*

cp ../../NigeriaFiscalization/publish/* ./Plugins/Nigeria

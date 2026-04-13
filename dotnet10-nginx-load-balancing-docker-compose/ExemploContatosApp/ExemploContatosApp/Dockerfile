# Essa primaira parte é só o build, dpeois ela é descartada para não ocupar memória
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Essa segunda parte é montada somente com o runtime para diminuir o tamnho da imagem (de 900mb para 350mg em média)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "ExemploContatosApp.dll" ]


# Subindo o containes
# docker build -t contatosapp .
# docker run -d -p 8080:8080 contatosapp:latest
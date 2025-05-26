FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS source

WORKDIR /src
COPY . .

FROM source as build

RUN dotnet tool restore \
 && dotnet restore \
 && dotnet build ReReDesign.sln

# [Stage 2] - Build result image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS release

ARG ReReDesign_Backend_DtfLoginSettings__Email
ARG ReReDesign_Backend_DtfLoginSettings__Password

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV DOCKER_COMP="main contrib"
ENV DOCKER_BUILDKIT=1

# Setting up timezone
RUN apk add --no-cache tzdata icu \
 && cp /usr/share/zoneinfo/Europe/Moscow /etc/localtime \
 && echo "Europe/Moscow" > /etc/timezone \
 && apk del tzdata

WORKDIR /app
COPY --from=build /src/publish/* ./

CMD dotnet VelikiyPrikalel.ReReDesign.Web.dll

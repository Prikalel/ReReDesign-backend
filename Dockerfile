FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine

WORKDIR /src
COPY . .

ARG ReReDesign_Backend_DtfLoginSettings__Email
ARG ReReDesign_Backend_DtfLoginSettings__Password

ENV DOTNET_NUGET_SIGNATURE_VERIFICATION=false
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV DOCKER_COMP="main contrib"
ENV DOCKER_BUILDKIT=1

# Setting up timezone
RUN apk add --no-cache tzdata icu \
 && cp /usr/share/zoneinfo/Europe/Moscow /etc/localtime \
 && echo "Europe/Moscow" > /etc/timezone \
 && apk del tzdata

CMD dotnet run ReReDesign.sln -c Release --project Source/ReReDesign.Web/ReReDesign.Web.csproj

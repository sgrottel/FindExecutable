#
# This docker can be used to test the linux implementation of FindExecutable
#
# On a Windows dev PC run:
#   docker build -t sgr/findexecutabletest .    
#   docker run --rm -v ".\bin\Debug\net10.0:/myapp" -t sgr/findexecutabletest
#
# Adjust path of the volume mount if you are to test other build flavors.
#

# https://hub.docker.com/_/microsoft-dotnet-runtime/
FROM mcr.microsoft.com/dotnet/runtime:10.0

RUN apt-get update && apt-get install -y git

VOLUME /myapp

WORKDIR /myapp

ENTRYPOINT ["dotnet", "FindExecutable.dll"]

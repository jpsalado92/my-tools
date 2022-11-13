# Docker Cheatsheet

## Pulling images

Pull image and tag it
```bash
docker pull <ImageURI> 
```

## Running images
```bash
# PowerShell
docker run `
   --rm `
   -p <LocalHostPort>:<ContainerPort> `
   --name MyContainerName `
   -e MyEnvVar=MyValue `
   -v <LocalHostPath>:<ContainerPath> `
   <ImageName>
```

## Other useful commands
```bash
# Stop all containers
docker stop $(docker ps -a -q)

# Remove all containers
docker rm $(docker ps -a -q)

# List all containers
docker ps

# List all images
docker images

# Remove image
docker rmi
```

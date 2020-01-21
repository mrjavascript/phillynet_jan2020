--------------------
TO CREATE
--------------------
dotnet new mvc --name DockerDemo

--------------------
TO RUN
--------------------
cd DockerDemo
dotnet restore
dotnet run 

--------------------
TO DOCKER
--------------------

# build 
docker build -t aspnetapp .

# run
docker run -d -p 8080:80 --name dockerdemo aspnetapp

# log in
aws ecr get-login

# tag image 
docker tag aspnetapp ACCOUNT_ID.dkr.ecr.us-east-1.amazonaws.com/demo_dotnet

# push to aws
docker push ACCOUNT_ID.dkr.ecr.us-east-1.amazonaws.com/demo_dotnet


----------------------
RETAG AN IMAGE
----------------------

MANIFEST=$(aws ecr batch-get-image --repository-name demo_dotnet --image-ids imageTag=latest --query 'images[].imageManifest' --output text)

aws ecr put-image --repository-name demo_dotnet --image-tag 1.0.0.RELEASE --image-manifest "$MANIFEST"

aws ecr describe-images --repository-name demo_dotnet

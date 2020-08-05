docker build -t generate-token .
docker run --init -d -p 3000:3000 -it generate-token
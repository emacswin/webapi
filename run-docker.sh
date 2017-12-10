docker build -t 1.1.5.-jessie
docker run -d -p 12345:27017 -p 5000:5000 -t 1.1.5-jessie

docker build -t 1.1.5-jessie .
docker run -d \
       --sysctl net.ipv6.conf.all.disable_ipv6=1 \
       -v /Users/ewu/dev/webapi/webapi/bin/Debug/netcoreapp1.1/publish:/root/webapi \
       -p 12345:27017 \
       -p 5000:5000 \
       -t 1.1.5-jessie

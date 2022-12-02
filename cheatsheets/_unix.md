## Process management 

last - show a (history) listing of last logged in users. 
pkill –U username - kill processes based on username. 
ps – u username - search processes based on username. 
pgrep –U username - search processes based on username. 

## User management 

Adduser jps 
usermod -aG sudo newuser –ADD USER TO SUDO GROUP  

USERS 
deluser --remove-all-files – REMOVE USER AND ALL FILES OWNED 
getent passwd {1000..60000} - GET LIST OF NORMAL USERS 
cat /etc/passwd - GET LIST OF ALL USERS 

GROUPS 
groups – LIST OF ALL GROUPS 
groups username – LIST OF ALL GROUPS A USERNAME BELONGS TO 

 

sudo systemctl enable docker 

sudo systemctl start docker 

docker run hello-world  

 

 

 

 

eval "$(pyenv init -)" 

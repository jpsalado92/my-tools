
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











REFERENCIAS 

Aprendizaje de BACH siguiendo los ejercicios de OverTheWire en: https://overthewire.org/wargames/bandit/bandit0.html 

 

Consejos y revisión de tareas completadas con S4VITAR: 

https://www.youtube.com/watch?v=RUorAzaDftg&t=2269s 

 

BANDIT5 (koReBOKuIDDepwhWk7jZC0RTdopnAYKh) 

 

BANDIT6 (DXjZPULLxYr17uwoI01bNLQbtFemEgo7) 

 

Look for file that is: 

owned by user bandit7 

owned by group bandit6 

33 bytes in size 

 

Find man page: https://man7.org/linux/man-pages/man1/find.1.html 

 

 

find / -user bandit7 -group bandit6 -size 33c 2>/dev/null | xargs cat 

 

Redireccionar errores al agujero negro /dev/null 

find . –user bandit7 -group bandit6 -type f 

Para independizar tareas: disown 

 

BANDIT7 (HKBPTKQnIay4Fw76bEy8PVxKEDQRKTzs) 

Contar número de líneas de un documento 

cat data.txt | wc –l 

Contar número de caracteres de un documento 

cat data.txt | wc –c 

 

 

cat data.txt | grep "^millionth" -n 

cat data.txt | grep "^millionth$" -n 

Buscar algo que empiece y ($ termine) por millionth y devolver número de línea 

 

cat data.txt | awk "NR==37262" 

devolver línea 37262 

 

Mejor hacer: grep "^millionth"  data.txt 

Coger segundo argumento:  grep "^millionth"  data.txt | awk '{print $2}' 

Coger según delimitador:  grep "^millionth"  data.txt | cut  -d ' ' -f 1 

 

Revertir con "rev" 

 

BANDIT8 (cvX2JJa4CFALtqS87jk27qwqGhBM9plV) 

cat data.txt | sort | uniq –u 

https://ryanstutorials.net/linuxtutorial/piping.php 

Every program we run on the command line automatically has three data streams connected to it. 

STDIN (0) - Standard input (data fed into the program) 

STDOUT (1) - Standard output (data printed by the program, defaults to the terminal) 

STDERR (2) - Standard error (for error messages, also defaults to the terminal) 

We can instead get the new data to be appended to the file by using the double greater than operator ( >> ). 

If we use the less than operator ( < ) then we can send data the other way. We will read data from the file and feed it into the program via it's STDIN stream. 

 

 

 

BANDIT9 (UsvVyFSfZZWbi6wgC7dAFyFuR6jQQUhR) 

cat data.txt | base64 

 

strings 

There can be two types of characters in a file; printable and non-printable. The alphanumeric characters, punctuation, or whitespaces are known as printable characters; except the printable character, all the characters are known as non-printable characters. 

In simple words, we can say that it extracts printable characters from files so that other commands can use the strings without non-printable characters. 

 

strings data.txt | grep = 

 

 

!$ = Mencionar último argumento de comando 

 

 

BANDIT10 (truKLdjsbJ5g7yyJ2X2R0o3a5HQJFuLk) [s4vitar 1h:13'] 

base64 -d data.txt  

 

tr sustituye un carácter por otro 

 

BANDIT11 (IFukwKGsFW8MOq3IRFqrxE1hxTNEbUPR) 

cat data.txt | tr '[H-ZA-Gh-za-g]' '[U-ZA-Tu-za-t]' | awk 'NF{print $NF}' 

 

 

BANDIT12 (5Te8Y4drgCRfCx8ugdwuEX8KFC6k2EUu) 

Comprimi 

 

BANDIT13 (8ZjyCRiBWFYkneahHwxCv3wb2a1ORpYL) 

BANDIT14 (4wcYUJFw0k0XLShlDzztnTBHiqxU3b3e)  

ssh bandit14@bandit.labs.overthewire.org -p 2220 

 

 

BANDIT15 (BfMYroe26WYalil77FoDi9qh59eK5xNr)  

 

 

BANDIT16 (cluFn7wTiGryunymYOu4RcffSxQluehd) 

 

ssh bandit16@bandit.labs.overthewire.org -p 2220 

 

https://overthewire.org/wargames/bandit/bandit17.html 

 

Goal: The credentials for the next level can be retrieved by submitting the password of the current level to a port on localhost in the range 31000 to 32000. First find out which of these ports have a server listening on them. Then find out which of those speak SSL and which don’t. There is only 1 server that will give the next credentials, the others will simply send back to you whatever you send to it. 

 

for port in {31990..32000}; do echo "port"; done; 

 

nmap localhost -p 31000-32000 

 

PORT      STATE SERVICE 

31046/tcp open  unknown 

31518/tcp open  unknown 

31691/tcp open  unknown 

31790/tcp open  unknown 

31960/tcp open  unknown 

 

openssl s_client -connect localhost:31790 

 

cluFn7wTiGryunymYOu4RcffSxQluehd 

Correct! 

-----BEGIN RSA PRIVATE KEY----- 

MIIEogIBAAKCAQEAvmOkuifmMg6HL2YPIOjon6iWfbp7c3jx34YkYWqUH57SUdyJ 

imZzeyGC0gtZPGujUSxiJSWI/oTqexh+cAMTSMlOJf7+BrJObArnxd9Y7YT2bRPQ 

Ja6Lzb558YW3FZl87ORiO+rW4LCDCNd2lUvLE/GL2GWyuKN0K5iCd5TbtJzEkQTu 

DSt2mcNn4rhAL+JFr56o4T6z8WWAW18BR6yGrMq7Q/kALHYW3OekePQAzL0VUYbW 

JGTi65CxbCnzc/w4+mqQyvmzpWtMAzJTzAzQxNbkR2MBGySxDLrjg0LWN6sK7wNX 

x0YVztz/zbIkPjfkU1jHS+9EbVNj+D1XFOJuaQIDAQABAoIBABagpxpM1aoLWfvD 

KHcj10nqcoBc4oE11aFYQwik7xfW+24pRNuDE6SFthOar69jp5RlLwD1NhPx3iBl 

J9nOM8OJ0VToum43UOS8YxF8WwhXriYGnc1sskbwpXOUDc9uX4+UESzH22P29ovd 

d8WErY0gPxun8pbJLmxkAtWNhpMvfe0050vk9TL5wqbu9AlbssgTcCXkMQnPw9nC 

YNN6DDP2lbcBrvgT9YCNL6C+ZKufD52yOQ9qOkwFTEQpjtF4uNtJom+asvlpmS8A 

vLY9r60wYSvmZhNqBUrj7lyCtXMIu1kkd4w7F77k+DjHoAXyxcUp1DGL51sOmama 

+TOWWgECgYEA8JtPxP0GRJ+IQkX262jM3dEIkza8ky5moIwUqYdsx0NxHgRRhORT 

8c8hAuRBb2G82so8vUHk/fur85OEfc9TncnCY2crpoqsghifKLxrLgtT+qDpfZnx 

SatLdt8GfQ85yA7hnWWJ2MxF3NaeSDm75Lsm+tBbAiyc9P2jGRNtMSkCgYEAypHd 

HCctNi/FwjulhttFx/rHYKhLidZDFYeiE/v45bN4yFm8x7R/b0iE7KaszX+Exdvt 

SghaTdcG0Knyw1bpJVyusavPzpaJMjdJ6tcFhVAbAjm7enCIvGCSx+X3l5SiWg0A 

R57hJglezIiVjv3aGwHwvlZvtszK6zV6oXFAu0ECgYAbjo46T4hyP5tJi93V5HDi 

Ttiek7xRVxUl+iU7rWkGAXFpMLFteQEsRr7PJ/lemmEY5eTDAFMLy9FL2m9oQWCg 

R8VdwSk8r9FGLS+9aKcV5PI/WEKlwgXinB3OhYimtiG2Cg5JCqIZFHxD6MjEGOiu 

L8ktHMPvodBwNsSBULpG0QKBgBAplTfC1HOnWiMGOU3KPwYWt0O6CdTkmJOmL8Ni 

blh9elyZ9FsGxsgtRBXRsqXuz7wtsQAgLHxbdLq/ZJQ7YfzOKU4ZxEnabvXnvWkU 

YOdjHdSOoKvDQNWu6ucyLRAWFuISeXw9a/9p7ftpxm0TSgyvmfLF2MIAEwyzRqaM 

77pBAoGAMmjmIJdjp+Ez8duyn3ieo36yrttF5NSsJLAbxFpdlc1gvtGCWW+9Cq0b 

dxviW8+TFVEBl1O4f7HVm6EpTscdDxU+bCXWkfjuRb7Dy9GOtt9JPsX8MBTakzh3 

vBgsyi/sN3RqRBcGU40fOoZyfAMT8s1m/uYv52O6IgeuZ/ujbjY= 

-----END RSA PRIVATE KEY----- 

 

BANDIT17 (RSA Anterior) 

ssh bandit17@bandit.labs.overthewire.org -p 2220 

 

https://overthewire.org/wargames/bandit/bandit18.html 

 

Goal: There are 2 files in the homedirectory: passwords.old and passwords.new. The password for the next level is in passwords.new and is the only line that has been changed between passwords.old and passwords.new 

 

NOTE: if you have solved this level and see ‘Byebye!’ when trying to log into bandit18, this is related to the next level, bandit19 

 

 

vim -d passwords.new passwords.old 

diff passwords.old passwords.new 

 

 

Line 43: kfBf3eYk5BPBRzwjqutbbfE887SVc5Yd 

 

BANDIT18 (kfBf3eYk5BPBRzwjqutbbfE887SVc5Yd) 

ssh bandit18@bandit.labs.overthewire.org -p 2220 

 

https://overthewire.org/wargames/bandit/bandit19.html 
# Solving [Bandit@overthewire.org](https://overthewire.org/wargames/bandit/)

## [Bandit Level 0 → Level 1](https://overthewire.org/wargames/bandit/bandit1.html)

```bash
ssh bandit0@bandit.labs.overthewire.org -p 2220
password: bandit0
```

Code to answer:

```bash
$ ls
readme

$ cat readme
NH2SXQwcBdpmTEzi3bvBHMM9H66vVXjL
```

## [Bandit Level 1 → Level 2](https://overthewire.org/wargames/bandit/bandit2.html)

```bash
ssh bandit1@bandit.labs.overthewire.org -p 2220
password: NH2SXQwcBdpmTEzi3bvBHMM9H66vVXjL
```

Code to answer:

```bash
$ ls
-

$ cat ./-
rRGizSaX8Mk1RTb1CNQoXTcYZWU6lgzi
```

 

## [Bandit Level 2 → Level 3](https://overthewire.org/wargames/bandit/bandit3.html)

```bash
ssh bandit2@bandit.labs.overthewire.org -p 2220
password: rRGizSaX8Mk1RTb1CNQoXTcYZWU6lgzi
```

Code to answer:

```bash
$ ls
spaces in this filename

$ cat spaces\ in\ this\ filename
aBZ0W5EmUfAf7kHTQeOwd8bauFJ2lAiG
```

## [Bandit Level 3 → Level 4](https://overthewire.org/wargames/bandit/bandit4.html)

```bash
ssh bandit3@bandit.labs.overthewire.org -p 2220
password: aBZ0W5EmUfAf7kHTQeOwd8bauFJ2lAiG
```

Code to answer:

```bash
~$ ls
inhere

~$ cd inhere/

~/inhere$ ls

~/inhere$ ls -la
total 12
drwxr-xr-x 2 root    root    4096 Sep  1 06:30 .
drwxr-xr-x 3 root    root    4096 Sep  1 06:30 ..
-rw-r----- 1 bandit4 bandit3   33 Sep  1 06:30 .hidden

~/inhere$ cat .hidden
2EW7BBsr6aMMoJ2HjW067dm8EgX26xNe
```

## [Bandit Level 4 → Level 5](https://overthewire.org/wargames/bandit/bandit5.html)

```bash
ssh bandit4@bandit.labs.overthewire.org -p 2220
password: 2EW7BBsr6aMMoJ2HjW067dm8EgX26xNe
```

> **Hint:** The password for the next level is stored in the only human-readable file in the inhere directory. Tip: if your terminal is messed up, try the “reset” command.

Code to answer:

```bash
~$ file ./inhere/*
./inhere/-file00: OpenPGP Public Key
./inhere/-file01: data
./inhere/-file02: data
./inhere/-file03: data
./inhere/-file04: data
./inhere/-file05: data
./inhere/-file06: data
./inhere/-file07: ASCII text
./inhere/-file08: data
./inhere/-file09: data

~$ cat ./inhere/-file07
lrIWWI6bB37kxfiCQZqUdOIYfr6eEeqR
```

> **Key-Takeaway:** Use the `file` command to display the type of the passed 

## [Bandit Level 5 → Level 6](https://overthewire.org/wargames/bandit/bandit6.html)

```bash
ssh bandit5@bandit.labs.overthewire.org -p 2220
password: lrIWWI6bB37kxfiCQZqUdOIYfr6eEeqR
```

> **Hint:** The password for the next level is stored in a file somewhere under the inhere directory and has all of the following properties:

```
human-readable
1033 bytes in size
not executable
```

Code to answer:

```bash
# In order to learn more about options
~$ man find | grep size
~$ man find | grep exe
~$ man find | grep readable

~/inhere$ find . -size 1033c -type f -readable | xargs cat | xargs
P4L4vucdmLnm8I7Vl7jG1ApGSfjYKqJU
```

> **Key-Takeaways:**
> * Use `find .` to get every file and folder under a given path.
> * Use `find . -type f` to look for only files.
> * Use `find . -readable` to look for only readable files.
> * Use `find . -size 1033c` to specify the bytes of the file.
> * Use `find . -executable` to look for executable files.
> * Use `!` before an option to complement it.
> * Pipe `xargs` to apply an operation to the output of the previous one. Concatenated removes the spaces of the final output.

## [Bandit Level 6 → Level 7](https://overthewire.org/wargames/bandit/bandit7.html)

```bash
ssh bandit6@bandit.labs.overthewire.org -p 2220
password: P4L4vucdmLnm8I7Vl7jG1ApGSfjYKqJU
```

> **Hint:** The password for the next level is stored somewhere on the server and has all of the following properties:
```
owned by user bandit7
owned by group bandit6
33 bytes in size
```
Code to answer:

```bash
# In order to learn more about options

~$ man find | grep user
~$ man find | grep group
~$ man find | grep readable

~$ find / -size 33c -user bandit7 -group bandit6 2>/dev/null | xargs cat
z7WtoNQU2XfjmMtWA8u5rN4vzqu4v99S
```

> **Key-Takeaways:**
> * Use `find . -user <USER_NAME>` to look for files owned by a user.
> * Use `find . -group <GROUP_NAME>` to look for files owned by a group.
> * Use `2>/dev/null` to redirect errors to dev null (kind of like a black hole).

## [Bandit Level 7 → Level 8](https://overthewire.org/wargames/bandit/bandit8.html)

```bash
ssh bandit7@bandit.labs.overthewire.org -p 2220
password: z7WtoNQU2XfjmMtWA8u5rN4vzqu4v99S
```

> **Hint:** The password for the next level is stored in the file **data.txt** next to the word **millionth**.

Code to answer:
```bash
~$ cat data.txt | grep millionth
TESKZC0XvTetK0S9xNwm25STk5iWrBvP
```

## [Bandit Level 8 → Level 9](https://overthewire.org/wargames/bandit/bandit9.html)

```bash
ssh bandit8@bandit.labs.overthewire.org -p 2220
password: TESKZC0XvTetK0S9xNwm25STk5iWrBvP
```

> **Hint:** The password for the next level is stored in the file **data.txt** and is the only line of text that occurs **only once**.


Code to answer:
```bash
~$ sort data.txt | uniq -u
EN632PlfYiZbn3PhVK3XOGSlNInNE00t
```

> **Key-Takeaway:** `uniq -u` takes care of adjacent duplicates, with the `-u` option, it outputs only unique lines


## [Bandit Level 9 → Level 10](https://overthewire.org/wargames/bandit/bandit10.html)

```bash
ssh bandit9@bandit.labs.overthewire.org -p 2220
password: EN632PlfYiZbn3PhVK3XOGSlNInNE00t
```
> **Hint:** The password for the next level is stored in the file **data.txt** in one of the few human-readable strings, preceded by several ‘=’ characters.

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd`

Code to answer:
```bash
~$ strings data.txt | grep ==
========== the
bu========== password
4iu========== is
b~==P
========== G7w8LIi6J3kTb8A7j9LgrywtEUlyyp6s
```
> **Key-Takeaway:** `strings` prints the printable character sequences that are at least 4 characters long (or the number given with the options below) and are followed by an unprintable character.



## [Bandit Level 10 → Level 11](https://overthewire.org/wargames/bandit/bandit11.html)

```bash
ssh bandit10@bandit.labs.overthewire.org -p 2220
password: G7w8LIi6J3kTb8A7j9LgrywtEUlyyp6s
```

> **Hint:** The password for the next level is stored in the file data.txt, which contains base64 encoded data.

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd`

Code to answer:
```bash
~$ base64 -d data.txt
The password is 6zPeziLdR2RKNdNYFNb6nVCKzphlXHBM
```
## [Bandit Level 11 → Level 12](https://overthewire.org/wargames/bandit/bandit12.html)

```bash
ssh bandit11@bandit.labs.overthewire.org -p 2220
password: 6zPeziLdR2RKNdNYFNb6nVCKzphlXHBM
```
> **Hint:** The password for the next level is stored in the file data.txt, where all lowercase (a-z) and uppercase (A-Z) letters have been rotated by 13 positions.

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd`






-------------------


 

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

 

## [Level 19](https://overthewire.org/wargames/bandit/bandit19.html )

Login

```bash
ssh bandit19@bandit.labs.overthewire.org -p 2220 
kfBf3eYk5BPBRzwjqutbbfE887SVc5Yd
```

 

https://overthewire.org/wargames/bandit/bandit19.html 

ssh bandit19@bandit.labs.overthewire.org -p 2220

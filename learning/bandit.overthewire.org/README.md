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
>
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
>
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

Code to answer:

```bash
~$ cat data.txt | tr '[A-Za-z]' '[N-ZA-Mn-za-m]'
The password is JVNBBFSmZwKKOP0XbFXOoW8chDz5yVRv
```

> **Key-Takeaways:**
>The `tr` command replaces characters according to a specific logic. In this example.
>
>* For upper case cases, we got 13 rotation using. "Map from A-Z to N-ZA-M"
>* For lower case cases, the same was performed by. "Map from a-z to n-za-m"

## [Bandit Level 12 → Level 13](https://overthewire.org/wargames/bandit/bandit13.html)

```bash
ssh bandit12@bandit.labs.overthewire.org -p 2220
password: JVNBBFSmZwKKOP0XbFXOoW8chDz5yVRv
```

> **Hint:** The password for the next level is stored in the file data.txt, which is a hexdump of a file that has been repeatedly compressed. For this level it may be useful to create a directory under /tmp in which you can work using mkdir. For example: mkdir /tmp/myname123. Then copy the datafile using cp, and rename it using mv (read the manpages!).

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd, mkdir, cp, mv, file`

Code to answer:

```bash
$ man xxd | grep hexdump
$ cd /tmp
$ mkdir my_test && cd my_test
$ cp ~/data.txt .

# 1st compressed file
$ man xxd | grep hexd
$ xxd -r data.txt > decompressed_data.txt
$ file decompressed_data.txt
'decompressed_data.txt: gzip compressed data, was "data2.bin", last modified: Thu Sep  1 06:30:09 2022, max compression, from Unix, original size modulo 2^32 575'

# 2nd compressed file
$ man gzip | grep decomp
$ cp decompressed_data.txt decompressed_data.gz
$ gzip -d decompressed_data.gz
$ file decompressed_data
'decompressed_data: bzip2 compressed data, block size = 900k'

# 3rd compressed file
$ man bzip2 | grep decomp
$ bzip2 -d decompressed_data
"bzip2: Can't guess original name for decompressed_data -- using decompressed_data.out"
$ file decompressed_data.out
'decompressed_data.out: gzip compressed data, was "data4.bin", last modified: Thu Sep  1 06:30:09 2022, max compression, from Unix, original size modulo 2^32 20480'

# 4th compressed file
$ mv decompressed_data.out decompressed_data.gz
$ gzip -d decompressed_data.gz
$ file decompressed_data
'decompressed_data: POSIX tar archive (GNU)'

# 5th compressed file
$ man tar | grep decomp
$ tar xvf decompressed_data
'data5.bin'
$ file data5.bin
'data5.bin: POSIX tar archive (GNU)'

# 6th compressed file
$ tar xvf data5.bin
'data6.bin'
$ file data6.bin
'data6.bin: POSIX tar archive (GNU)'

# 7th compressed file
$ tar xvf data6.bin
'data8.bin'
$ file data8.bin
$ mv data8.bin data8.gz
$ gzip -d data8.gz
$ file data8
$ cat data8
'The password is wbWdlBxEir4CaE8LaPhauuOo6pwRmrDw'
```

## [Bandit Level 13 → Level 14](https://overthewire.org/wargames/bandit/bandit14.html)

```bash
ssh bandit13@bandit.labs.overthewire.org -p 2220
password: 'wbWdlBxEir4CaE8LaPhauuOo6pwRmrDw'
```

> **Hint:** The password for the next level is stored in `/etc/bandit_pass/bandit14` and can only be read by user bandit14. For this level, you don’t get the next password, but you get a private SSH key that can be used to log into the next level.

> **Note:** localhost is a hostname that refers to the machine you are working on.

> **Possible commands:** `ssh, telnet, nc, openssl, s_client, nmap`

Code to answer:

```bash
$cat sshkey.private
$ssh --help
$ssh bandit14@localhost -p 2220 -i sshkey.private
```

## [Bandit Level 14 → Level 15](https://overthewire.org/wargames/bandit/bandit15.html)

```bash
ssh bandit14@bandit.labs.overthewire.org -p 2220
password: 'fGrHPx402xGC7U7rXKDaxiWFTOiF0ENq'
```

> **Hint:** The password for the next level can be retrieved by submitting the password of the current level to port 30000 on localhost.

> **Possible commands:** `ssh, telnet, nc, openssl, s_client, nmap`

Code to answer:

```bash
$cat /etc/bandit_pass/bandit14
'fGrHPx402xGC7U7rXKDaxiWFTOiF0ENq'
$man nc localhost  30000 < fGrHPx402xGC7U7rXKDaxiWFTOiF0ENq
$cat /etc/bandit_pass/bandit14 | nc localhost 30000
"Correct!"
"jN2kgmIXJ6fShzhT2avhotn4Zcka6tnt"
```

# Linux cheatsheet

## General

### Get execution code for the previous command

```bash
echo $?
```

## The `cut` command

Given a file or standard output **with one or more lines**, the `cut` command allows the user to print selected parts of lines from each input to standard output. It will work in the following scenarios:

### Select ranges of characters `c` or bytes `-b`

```bash
$ cat state.txt
Andhra Pradesh
Arunachal Pradesh
Assam

# Position range selection
$ cut -c 1-3,5-7 state.txt
Andra
Aruach
Assm

# Unit position selection
$ cut -c 1,2,3 state.txt
And
Aru
Ass

# Range from start to end
$ cut -c 1- state.txt

# Range from start to 3rd pos
$ cut -c -3 state.txt
```

### Select fields `-f` separated by `-d`

To select the first column only:

```bash
$ cat test.txt
col1,col2,col3,col4,col5
val1,val2,val3,val4,val5

$ cut --complement -d "," -f 1 test.txt
col1
val1
```

### Select the complement of the specified fields

To select all but the first column:
1. Select the fields using `-f`.
2. Use `--complement` to complement the selection.

```bash
$ cat test.txt
col1,col2,col3,col4,col5
val1,val2,val3,val4,val5

$ cut --complement -d "," -f 1 test.txt
col2,col3,col4,col5
val2,val3,val4,val5
```

### Change delimiters of a file

1. Select all fields with `-f 1-`.
2. Use `-d` to specify the input delimiter and `–output-delimiter` to specify the output delimiter.

```bash
$ cat test.txt
col1,col2,col3
val1,val2,val3

$ cut -d "," -f 1- test.txt --output-delimiter=';'
col1;col2;col3
val1;val2;val3
```

## The `sort` command

Print the output of a file in given order.

```bash
$ cat test.txt
2
1
3

$ sort test.txt
1
2
3
```

Sometimes, we need data in reverse order i.e., the opposite of alphabetical order. This is accomplished by using the `-r` option, as seen below:

```bash
$ sort test.txt
3
2
1
```

Like letter sorting, we can sort **numerically** as well. Option `-n` organizes the numerical and reverses your results using `-r` option.

```bash
$ cat numeric.txt
14
04
34
1891
938
378
2356

$ sort -n numeric.txt
04
14
34
378
938
1891
2356
```

You can sort the **specific column** as well:
1. Select the desired column with `-k`
2. Select the column delimiter `-t`

```bash

$ cat file2.txt
Advika 1
Amit 30
Ajit 28
Abhi 278
Chirag 2

$ sort -t -k 2 file2.txt
Advika 1
Chirag 2
Abhi 278
Ajit 28
Amit 30

```

Often, there are many duplicate entries in some lines. Those can be eliminated by using the `-u` option.

```bash
$ cat test.txt
Dr.B.R.Ambedkar
MahatmaJyotibaPhule
ChatrapatiShahuMaharaj
Dr.B.R.Ambedkar
budhha
Ramaai
Dr.B.R.Ambedkar

$ sort -u test.txt
budhha
ChatrapatiShahuMaharaj
Dr.B.R.Ambedkar
MahatmaJyotibaPhule
Ramaai
```

Source: https://www.redhat.com/sysadmin/sort-command-linux

## The `head` command

Returns the desired amount of lines from the text given to it via standard input.

By default, it returns the first ten lines of the input given, but it may be extended or decreased providing an int to the `-n` option.

```bash
$ cat sample.txt
Lorem Ipsum is simply dummy text of the printing and
typesetting industry. Lorem Ipsum has been the industrys
standard dummy text ever since the 1500s, when an unknown
printer took a galley of type and scrambled it to make
a type specimen book. It has survived not only five
centuries, but also the leap into electronic typesetting,
remaining essentially unchanged.

$ head -n 3 sample.txt
Lorem Ipsum is simply dummy text of the printing and
typesetting industry. Lorem Ipsum has been the industrys
standard dummy text ever since the 1500s, when an unknown
```

It is also possible to limit the number of bytes with the `-c` option. In the following example they number of bytes retrieved is limited to **50**.

```
$ head -c 50 sample.txt
Lorem Ipsum is simply dummy text of the printing ar
```

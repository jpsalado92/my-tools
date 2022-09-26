# Command Line Interface (CLI) cheatsheet

## Powershell


### Get source for a given command
```
Get-Command python
gcm python
```

### Check for look alike commands in history
Press key f8 while typing the command.

## Linux

### Selecting given option

```
my_string="62499 2022-09-14T04:07:05Z gs://my_byucket/yy/zz/xx/my_file.csv"
echo $my_string | awk '{print $2}
2022-09-14T04:07:05Z
```
### Replacing values from a string

```
my_string="2022-09-14T04:07:05Z"
echo $my_string | tr TZ " "
2022-09-14 04:07:05
```

### Get execution code for previous command
```
echo $?
```

### Commands: `cut` 
Given a file or standard output with one or more lines, the `cut` command allows the user to print selected parts of lines from each input to standard output. It will work in the following scenarios:

**Sample data**

```bash
$ cat state.txt
Andhra Pradesh
Arunachal Pradesh
Assam
```

**Select ranges of characters `c` or bytes `-b`**

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

**Select fields `-f` separated by `-d`**

```bash
$ cut -d " " -f 2 state.txt
Pradesh
Pradesh
Assam
```

**Select all fields but those indicated by `-f` separated by `-d` usinc complement `--complement`**

```bash
$ cut --complement -d " " -f 2 state.txt
Andhra
Arunachal
Assam
```

**Select all fields and use a custom delimiter to separate them `–output-delimiter`**
```bash
$ cut -d " " -f 1- state.txt --output-delimiter='%'
Pradesh
Pradesh
Assam
```

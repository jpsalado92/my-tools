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

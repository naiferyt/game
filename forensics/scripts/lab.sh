#!/bin/bash
# lab.sh <file> <startLabel|line> <endLabel|line> : raw lines between two label definitions (or line numbers)
f=$1
ln() { if [[ "$1" =~ ^[0-9]+$ ]]; then echo $1; else grep -n "^$1:" "$f" | head -1 | cut -d: -f1; fi; }
a=$(ln $2); b=$(ln $3)
sed -n "${a},${b}p" "$f" | grep -v "ldr     lr, \[r[0-9]*\]\s*$" | sed 's/  *$//; s/(this-class: \([^)]*\))/<\1>/'

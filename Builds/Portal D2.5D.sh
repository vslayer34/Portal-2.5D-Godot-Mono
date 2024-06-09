#!/bin/sh
echo -ne '\033c\033]0;Portal D2.5D\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/Portal D2.5D.x86_64" "$@"

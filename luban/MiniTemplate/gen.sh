#!/bin/bash

WORKSPACE=..
LUBAN_DLL=$WORKSPACE/Tools/Luban/Luban.dll
CONF_ROOT=.

dotnet $LUBAN_DLL \
    -t client \
    -c cs-simple-json \
    -d json \
    --conf $CONF_ROOT/luban.conf \
    -x outputCodeDir=../../UnityProject/Assets/HotUpdate/Data \
    -x outputDataDir=../../UnityProject/Assets/Arts/Data
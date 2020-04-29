#!/bin/bash

WIFI_IF='wlan0'
MON_IF="${WIFI_IF}mon"
TMP='/tmp'
DMP_EXT='cap'
NULL="/dev/null"

start() {
  local PKGS=("aircrack-ng" "hashcat")

  for PKG in ${PKGS[@]}; do
    if [[ `apt-cache show $PKG | grep -c $PKG` == 0 ]]; then
	  apt-get install -f $PKG &>$NULL
	fi
  done

  nice -n -20 airmon-ng start $WIFI_IF &>$NULL && airmon-ng check kill &>$NULL
  #nice -n -20 airodump-ng $MON_IF #Scanning WiFi stations
}
stop() {
  clear_tmp
  airmon-ng stop $MON_IF &>$NULL
  /etc/init.d/network-manager restart &>$NULL && /etc/init.d/networking restart &>$NULL
}

add() {
  local BSSID="$1"
  local CHNL="$2"
  local DMP_NAME="-01.${DMP_EXT}"
  local ID_NAME=`echo ${BSSID} | sed 's/://g'`
  local NEW_NAME="${ID_NAME}.${DMP_EXT}"
  local CAP2="/usr/lib/hashcat-utils/cap2hccapx.bin"
  local HCC_EXT='hccaxp'

  cd "$TMP"
  
  clear_tmp
  nice -n -5 airodump-ng -c $CHNL --bssid $BSSID -w $TMP/ $MON_IF
  
  if [ -f "$DMP_NAME" ]; then
	mv "$DMP_NAME" "$NEW_NAME" &>$NULL;
	nice -n -10 $CAP2 "$NEW_NAME" "$ID_NAME.$HCC_EXT" &>$NULL;
	return 0
  else
	return 1
  fi
}

clear_tmp() {
  EXT_ARR=("*.$DMP_EXT" "*.csv" "*.netxml")
  cd "$TMP"
  nice -n -10 rm -f "${EXT_ARR[*]}" &>$NULL
}

help(){
  echo "$0 {start|stop|restart|add [BSSID] [CHANNEL]|import-file [PATH TO FILE] }"
  return 1
}

check_attrs() {
  if [ ! -z "$1" ] && [ "$#" == "$1" ]; then
	return 0
  fi

  help
}

import_file(){
  local FL_PTH="$1"

  cat $FL_PTH | while read BSSID CHNL
  do
	if [ -z `echo $BSSID | grep -a '#'` ]; then
	  ./$0 add $BSSID $CHNL &
	fi
  done < $FL_PTH
}
case "$1" in
  start)
	start
  ;;
  stop)
	stop
  ;;
  restart)
	stop
	start
  ;;
  add)
	if [ "`check_attrs 2 | echo $?`" == 0 ]; then
	  add $2 $3
	fi
  ;;
  import-file)
	if [ "`check_attrs 1 | echo $?`" == 0 ]; then
	  import_file $2
	fi
  ;;
  *)
	help
  ;;
esac

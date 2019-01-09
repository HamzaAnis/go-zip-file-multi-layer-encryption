package main

import (
	"fmt"
	"log"
	"os"
)

func readPassFile() {

}

func file_is_exists(f string) bool {
	_, err := os.Stat(f)
	if os.IsNotExist(err) {
		return false
	}
	return err == nil
}

func print_error(msg string) {
	log.Println("error: " + msg)
}
func main() {
	fmt.Println("Enter the name of the file to encrypt: ")
	inputFile := ""
	fmt.Scanf("%s\n", &inputFile)
	if file_is_exists(inputFile) {
		fmt.Println("Enter the name of the password file: ")
		passwordFile := ""
		fmt.Scanf("%s\n", &passwordFile)
		fmt.Println(passwordFile)
		if file_is_exists(passwordFile) {
			fmt.Println("Working")
		} else {
			print_error(passwordFile + " do not exist, program exiting!!")
		}
	} else {
		print_error(inputFile + " file do not exist, program exiting!!")
	}
}

package main

import (
	"errors"
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"strings"
)

func readPassFile(f string) ([]string, error) {
	content, err := ioutil.ReadFile(f)
	if err != nil {
		return nil, errors.New("invalid file name")
	}
	passwords := strings.Split(string(content), "\n")
	return passwords, nil
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
	// fmt.Println("Enter the name of the file to encrypt: ")
	// inputFile := ""
	// fmt.Scanf("%s\n", &inputFile)
	// if file_is_exists(inputFile) {
	// 	fmt.Println("Enter the name of the password file: ")
	// 	passwordFile := ""
	// 	fmt.Scanf("%s\n", &passwordFile)
	// 	fmt.Println(passwordFile)
	// 	if file_is_exists(passwordFile) {
	// 		fmt.Println("Working")
	// 	} else {
	// 		print_error(passwordFile + " do not exist, program exiting!!")
	// 	}
	// } else {
	// 	print_error(inputFile + " file do not exist, program exiting!!")
	// }
	inputFile := "input.txt"

	_, err := ioutil.ReadFile(inputFile)
	if err != nil {
		print_error(inputFile + " do not exist or invalid file name, program exiting")
		return
	}

	passwordFile := "passwords.txt"
	passwords, err := readPassFile(passwordFile)
	if err != nil {
		print_error(passwordFile + " do not exist or invalid file name, program exiting")
		return
	}
	fmt.Println(len(passwords))
	for index := len(passwords) - 1; index >= 0; index-- {
		fmt.Println(passwords[index])
	}
}

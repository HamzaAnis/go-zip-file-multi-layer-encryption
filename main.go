package main

import (
	"archive/zip"
	"bytes"
	"errors"
	"fmt"
	"io"
	"io/ioutil"
	"log"
	"os"
	"strings"

	"github.com/alexmullins/zip"
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

	text, err := ioutil.ReadFile(inputFile)
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
		contents := make([]byte, 0)
		if index == len(passwords) {
			contents := text
		} else {
			previousZipFileName := fmt.Sprintf("./%s.zip", index+1)
			previousZipFileContent, err := ioutil.ReadFile(previousZipFileName)
			if err != nil {
				print_error("while reading " + previousZipFileName)
				return
			}
		}
		zipFileName := fmt.Sprintf("./%s.zip", index)
		fzip, err := os.Create(zipFileName)
		if err != nil {
			print_error("while creating zip files")
		}
		zipw := zip.NewWriter(fzip)
		defer zipw.Close()
		w, err := zipw.Encrypt(`test.txt`, passwords[index])
		if err != nil {
			log.Fatal(err)
		}
		_, err = io.Copy(w, bytes.NewReader(contents))
		if err != nil {
			log.Fatal(err)
		}
		zipw.Flush()
	}
}

# Wiattend

## Requirements

For this tutorial you need to have installed [Git](https://git-scm.com/downloads), [NodeJS](https://nodejs.org) and [MySQL](https://www.mysql.com/).

## Demo

[![RFID Attendance System - ESP32 - NodeJS + MySQL](https://img.youtube.com/vi/TH8eR9hSwzc/hqdefault.jpg)](https://www.youtube.com/watch?v=TH8eR9hSwzc)

## Commands

  - Server

    Clone repo
    
    ```
    git clone "https://github.com/abobija/wiattend-srv.git"
    cd wiattend-srv
    ```
    
    Edit configuration file at path `src/config.js`
    
    Install node dependencies & start the server
    
    ```
    npm i
    npm start
    ```

  - Electronics

    ```
    git clone --recurse-submodules "https://github.com/abobija/wiattend.git"
    cd wiattend
    ```
    
    Edit configuration file `config.json` & upload files to ESP32 (set your COM port).
    
    ```
    npm i
    npm run upload -- --port=COM7
    ```

  - Client

    ```
    git clone "https://github.com/abobija/wiattend-client.git"
    ```
    
    Edit configuration file `config.js` and start client by opening `index.html` file.

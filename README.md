# 4uChat - Version 1.0

## Description
4uChat is a real-time chat application that allows instant communication between users. This is version 1.0, which consists of a Node.js server using the Socket.IO library and a C# client implemented with Windows Forms to consume and replicate chat actions.

## Features
- Real-time communication: Users can exchange messages in real time, enabling instant communication.
- User-friendly interface: The C# client is developed using Windows Forms, offering an easy-to-use and intuitive interface.
- Multiple user support: Multiple users can connect to the chat simultaneously and exchange messages with each other.

## Installation Guide

### Prerequisites
- Node.js (version 20.3.0 or higher) installed on your system.
- Visual Studio development environment to run the C# client.

### Node.js Server Setup

1. Open a terminal or command prompt.
2. Navigate to the Node.js server folder (`Server Node.JS`).
3. Run the following command to install project dependencies:
   ```
   npm install
   ```
4. After the installation is complete, run the following command to start the server:
   ```
   npm run dev
   ```
5. The server will be running and ready to accept client connections.

### Running the C# Client

1. Open the C# client folder (`Chatv2`) in your C# development environment (e.g., Visual Studio).
2. Build and run the application.
3. The client interface will be displayed.
4. Enter the necessary information (e.g., username) to connect to the Node.js server.
5. Click the "Connect" button to establish the connection to the server.
6. After a successful connection, you will be able to exchange messages with other connected users.

## Contribution
If you would like to contribute to the development of 4uChat, feel free to send pull requests or open issues in our GitHub repository: [link to 4uChat repository](https://github.com/victor-0x29a/4uchat)

We hope you enjoy using 4uChat!

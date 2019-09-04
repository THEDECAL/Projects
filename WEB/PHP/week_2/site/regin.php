<?php
$_POST = array_map('strip_tags', $_POST);
require_once 'connect.php';

$email = '';
$login = '';
$password = '';
extract($_POST);

//Дописать проверку и фильтрование ведённых данных

$stmt = $pdo->prepare('INSERT INTO logins (`email`, `login`, `password`) VALUES (?,?,?)');
$stmt->bindValue(1, $email);
$stmt->bindValue(2, $login);
$stmt->bindValue(3, $password);

$stmt->execute();

header("Location: ../index.php");
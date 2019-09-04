<?php
$_POST = array_map('strip_tags', $_POST);
if(!isset($_POST['submit'])){
	extract($_POST);

	echo "<form method='post' action='site/editphoto.php' enctype='multipart/form-data'>
	  <div class='form-group'>
	  	<input type='hidden' name='id' value='$id'>
	  	<input type='hidden' name='file_name' value='$file_name'>
	  	<input type='hidden' name='file_ext' value='$file_ext'>
	    <label for='name'>Название:</label>
	    <input required name='name' class='form-control' id='name' placeholder='Введите название вашего фото...' value='$name'>
	  </div>
	  <div class='form-group'>
	    <label for='description'>Описание:</label>
	    <input name='description' class='form-control' id='description' placeholder='Введите описание вашего фото...' value='$description'>
	  </div>
	  <div class='form-group'>
	    <label for='image'>Изображение:</label>
	    <input name='image' type='file' class='form-control-file' id='image' placeholder='Введите описание вашего фото...' accept='image/*'>
	  </div>
	  <button type='submit' name='submit' class='btn btn-primary'>Добавить</button>
	</form>";
}
else{
	require_once 'connect.php';

	session_start();
	extract($_POST);

	//Дописать проверку и фильтрование ведённых данных

	$login_id = $_SESSION['login_id'];

	if ($_FILES and $_FILES['image']['error'] == 0){
		$dir_images = '../images/';
		$tmp_name = $_FILES['image']['tmp_name'];
		$file_ext = pathinfo($_FILES['image']['name'], PATHINFO_EXTENSION);
		$file_name = uniqid();

		rename($tmp_name, $dir_images . $file_name . '.' . $file_ext);
	}

	$query = "UPDATE photos SET `login_id` = ?, `name` = ?, `description` = ?, `file_name` = ?, `file_ext` = ? WHERE id=$id";
	$stmt = $pdo->prepare($query);

	$stmt->bindValue(1, $login_id, PDO::PARAM_INT);
	$stmt->bindValue(2, $name);
	$stmt->bindValue(3, $description);
	$stmt->bindValue(4, $file_name);
	$stmt->bindValue(5, $file_ext);
	$stmt->execute();

	header('Location: ../index.php');
}

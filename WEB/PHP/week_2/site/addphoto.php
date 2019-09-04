<?php
$_POST = array_map('strip_tags', $_POST);
if(!isset($_POST['submit'])){
	echo "<form method='post' action='site/addphoto.php' enctype='multipart/form-data'>
	  <div class='form-group'>
	    <label for='name'>Название:</label>
	    <input required name='name' class='form-control' id='name' placeholder='Введите название вашего фото...'>
	  </div>
	  <div class='form-group'>
	    <label for='description'>Описание:</label>
	    <input name='description' class='form-control' id='description' placeholder='Введите описание вашего фото...'>
	  </div>
	  <div class='form-group'>
	    <label for='image'>Изображение:</label>
	    <input required name='image' type='file' class='form-control-file' id='image' placeholder='Введите описание вашего фото...' accept='image/*'>
	  </div>
	  <button type='submit' name='submit' class='btn btn-primary'>Добавить</button>
	</form>";
}
else{
	require_once 'connect.php';

	session_start();

	$name = '';
	$description = '';
	extract($_POST);

	//Дописать проверку и фильтрование ведённых данных

	if ($_FILES and $_FILES['image']['error'] == 0){
		$dir_images = '../images/';
		$tmp_name = $_FILES['image']['tmp_name'];
		$file_ext = pathinfo($_FILES['image']['name'], PATHINFO_EXTENSION);
		$file_name = uniqid();
		$login_id = $_SESSION['login_id'];
		rename($tmp_name, $dir_images . $file_name . '.' . $file_ext);

		$query = "INSERT INTO photos (`login_id`, `name`, `description`, `file_name`, `file_ext`) VALUES (?, ?, ?, ?, ?)";
		$stmt = $pdo->prepare($query);

		$stmt->bindValue(1, $login_id, PDO::PARAM_INT);
		$stmt->bindValue(2, $name);
		$stmt->bindValue(3, $description);
		$stmt->bindValue(4, $file_name);
		$stmt->bindValue(5, $file_ext);
		$stmt->execute();
	}

	header('Location: ../index.php');
}

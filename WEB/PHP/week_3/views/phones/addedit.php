<?php

// use yii\helpers\url;
use yii\helpers\Html;

$id = '';
$brand = '';
$model = '';
$price = '';
if(isset($phone)){
	$id = $phone->getId();
	$brand = $phone->getBrand();
	$model = $phone->getModel();
	$price = $phone->getPrice();
}
?>
<form method="post" enctype="multipart/form-data">
	<input hidden name="_csrf" value="<?=Yii::$app->request->getCsrfToken()?>"/>
	<input hidden name="id" value="<?= $id ?>"/>
    <div class="form-group">
        <label for="brand">Брэнд:</label>
        <input required type="text" name="brand" class="form-control" id="brand" placeholder="Брэнд" value="<?= $brand ?>">
    </div>
    <div class="form-group">
        <label for="model">Модель:</label>
        <input required type="text" name="model" class="form-control" id="model" placeholder="Модель" value="<?= $model ?>">
    </div>
    <div class="form-group">
        <label for="price">Цена:</label>
        <input required type="number" name="price" class="form-control" id="price" placeholder="Цена" value="<?= $price ?>">
    </div>
    <div class="form-group">
        <label for="file">Изображение:</label>
        <input type="file" name="file" class="form-control" id="file">
    </div>
    <button type="submit" class="btn btn-primary">Добавить</button>
</form>
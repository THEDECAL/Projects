<?php

use yii\helpers\Html;
use yii\grid\GridView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Новости';
//$this->params['breadcrumbs'][] = $this->title;
?>
<div class="news-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= (SiteController::checkOnAdmin())?Html::a('Создать Новость', ['create'], ['class' => 'btn btn-success']):'' ?>
    </p>

    <?php foreach ($dataProvider->getModels() as $news) { ?>

        <hr>

        <h3><?= $news->title ?></h3>

        <h4><?= $news->text ?></h4>

        <p style="margin-top: 20px; text-align: right"><?= $news->date ?></p>

        <hr>

    <?php } ?>

</div>

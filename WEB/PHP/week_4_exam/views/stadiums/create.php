<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Stadiums */

$this->title = 'Добавить Стадион';
$this->params['breadcrumbs'][] = ['label' => 'Стадионы', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="stadiums-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>

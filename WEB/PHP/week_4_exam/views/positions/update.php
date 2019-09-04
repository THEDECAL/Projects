<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Positions */

$this->title = 'Изменить Роль: ' . $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Позиции игроков', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->name, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Изменить';
?>
<div class="roles-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model
    ]) ?>

</div>

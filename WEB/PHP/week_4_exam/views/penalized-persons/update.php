<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\PenalizedPersons */

$this->title = 'Update Penalized Persons: ' . $model->id;
$this->params['breadcrumbs'][] = ['label' => 'Penalized Persons', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->id, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="penalized-persons-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>

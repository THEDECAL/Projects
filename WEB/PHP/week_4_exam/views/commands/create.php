<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Commands */

$this->title = 'Добавить Комманду';
$this->params['breadcrumbs'][] = ['label' => 'Комманды', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="commands-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
        'stadiums' => $stadiums,
    ]) ?>

</div>

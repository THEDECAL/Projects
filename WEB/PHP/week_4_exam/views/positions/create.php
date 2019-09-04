<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Positions */

$this->title = 'Добавить Роль';
$this->params['breadcrumbs'][] = ['label' => 'Роли игроков', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="roles-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>

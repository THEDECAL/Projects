<?php

namespace app\models;

use \yii\db\ActiveQuery;

class PlayersQuery extends ActiveQuery
{

    public function all($db = null)
    {
        return parent::all($db);
    }

    public function one($db = null)
    {
        return parent::one($db);
    }
}

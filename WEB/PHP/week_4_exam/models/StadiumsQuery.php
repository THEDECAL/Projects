<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[Stadiums]].
 *
 * @see Stadiums
 */
class StadiumsQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return Stadiums[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return Stadiums|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}

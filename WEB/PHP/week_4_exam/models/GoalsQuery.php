<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[Goals]].
 *
 * @see Goals
 */
class GoalsQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return Goals[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return Goals|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}

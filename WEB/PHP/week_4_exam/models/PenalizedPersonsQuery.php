<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[PenalizedPersons]].
 *
 * @see PenalizedPersons
 */
class PenalizedPersonsQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return PenalizedPersons[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return PenalizedPersons|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}

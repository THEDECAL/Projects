<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[Matches]].
 *
 * @see Matches
 */
class MatchesQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return Matches[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return Matches|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}

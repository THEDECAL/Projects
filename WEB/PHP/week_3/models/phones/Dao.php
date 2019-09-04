<?php

namespace app\models\phones;

interface Dao
{
    function get($id);
    function getAll();
    function delete($id);
    function update($item);
    function save($item);
}

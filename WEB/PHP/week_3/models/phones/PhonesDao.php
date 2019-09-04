<?php

namespace app\models\phones;

use yii;
use app\models\phones\Phone;

final class PhonesDao implements Dao
{
	private static $db;
	private static $instance;
	private function __construct(){
		static::$db = Yii::$app->db;
	}
	public static function getInstance(): PhonesDao{
		if(static::$instance === null){
			static::$instance = new PhonesDao();
		}
		return static::$instance;
	}
	public function get($id): Phone{
		$query = "SELECT * FROM phones WHERE id = $id AND isDelete = FALSE";
		$phone = static::$db->CreateCommand($query)->queryOne();
		extract($phone);
		return new Phone(
			$id,
			$brand,
			$model,
			$price,
			$imageFileName
		);
	}
	public function getAll(): array{
		$query = 'SELECT * FROM phones WHERE isDelete = FALSE';
		$dbPhones = static::$db->CreateCommand($query)->queryAll();

		$phones = [];
		foreach ($dbPhones as $p){
			extract($p);
			array_push($phones, new Phone(
				$id,
				$brand,
				$model,
				$price,
				$imageFileName
			));
		}
		return $phones;
	}
	public function delete($id){
		return static::$db->CreateCommand()
					->update('phones', ['isDelete' => TRUE], "id = $id")
					->execute();
	}
	public function update($item){
		return static::$db->CreateCommand()
					->update('phones',
					[
						'brand' => $item->getBrand(),
						'model' => $item->getModel(),
						'price' => $item->getPrice(),
						'imageFileName' => $item->getImageFileName()
					],
					"id = {$item->getId()}")
					->execute() === 1 ? true : false;
	}
	public function save($item){
		static::$db->CreateCommand()
				->insert('phones',
					[
						'brand' => $item->getBrand(),
						'model' => $item->getModel(),
						'price' => $item->getPrice(),
						'imageFileName' => $item->getImageFileName()
					])->execute() === 1 ? true : false;
	}
}
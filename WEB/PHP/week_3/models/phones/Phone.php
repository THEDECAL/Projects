<?php

namespace app\models\phones;

class Phone{
	private $id;
	private $brand;
	private $model;
	private $price;
	private $imageFileName;
	public function __construct($id,
								$brand,
								$model,
								$price,
								$imageFileName){
		$this->id = $id;
		$this->brand = $brand;
		$this->model = $model;
		$this->price = $price;
		$this->imageFileName = $imageFileName;
	}
	public function getId(){ return $this->id; }

	public function getBrand(){ return $this->brand; }

	public function getModel(){ return $this->model; }

	public function getPrice(){ return $this->price; }

	public function getImageFileName(){ return $this->imageFileName; }

	public function getPathToImage(){ return '../views/phones/images/' . $this->imageFileName; }

	public function setId($id){ $this->id = $id; }

	public function setBrand($brand){ $this->brand = $brand; }

	public function setModel($model){ $this->model = $model; }

	public function setPrice($price){ $this->price = $price; }

	public function setImageFile($imageFileName){ $this->imageFileName = $imageFileName; }
}
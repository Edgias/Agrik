﻿using Edgias.Agrik.API.Interfaces;
using Edgias.Agrik.API.Models.Form;
using Edgias.Agrik.API.Models.View;
using Edgias.Agrik.ApplicationCore.Entities;
using Edgias.Agrik.ApplicationCore.Exceptions;
using Edgias.Agrik.ApplicationCore.Interfaces;
using Edgias.Agrik.ApplicationCore.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edgias.Agrik.API.Controllers
{
    [ApiController]
    [Route("v1.0/field-measurements")]
    public class FieldMeasurementsController : ControllerBase
    {
        private readonly IAppLogger<FieldMeasurementsController> _logger;
        private readonly IAsyncRepository<FieldMeasurement> _repository;
        private readonly IMapper<FieldMeasurement, FieldMeasurementFormApiModel, FieldMeasurementApiModel> _mapper;

        public FieldMeasurementsController(IAppLogger<FieldMeasurementsController> logger,
            IAsyncRepository<FieldMeasurement> repository,
            IMapper<FieldMeasurement, FieldMeasurementFormApiModel, FieldMeasurementApiModel> mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IReadOnlyList<FieldMeasurement> fieldMeasurements = await _repository.GetAllAsync();

            if (fieldMeasurements.Any())
            {
                return Ok(fieldMeasurements.Select(c => _mapper.Map(c)));
            }

            return NoContent();
        }

        [HttpGet("{skip}/{take}/{searchQuery?}")]
        public async Task<IActionResult> Get(int skip, int take, string searchQuery = null)
        {
            IReadOnlyList<FieldMeasurement> fieldMeasurements = await _repository.GetAsync(new FieldMeasurementSpecification(skip, take, searchQuery));

            if (fieldMeasurements.Any())
            {
                ApiResponse<FieldMeasurementApiModel> response = new ApiResponse<FieldMeasurementApiModel>
                {
                    Data = fieldMeasurements.Select(c => _mapper.Map(c)),
                    Count = await _repository.CountAsync(new FieldMeasurementSpecification(searchQuery))
                };

                return Ok(response);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            FieldMeasurement fieldMeasurement = await _repository.GetByIdAsync(id);

            if (fieldMeasurement == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(fieldMeasurement));
        }

        [HttpPost]
        public async Task<IActionResult> Post(FieldMeasurementFormApiModel apiModel)
        {
            try
            {
                FieldMeasurement fieldMeasurement = _mapper.Map(apiModel);

                fieldMeasurement = await _repository.AddAsync(fieldMeasurement);

                return CreatedAtAction(nameof(GetById), new { id = fieldMeasurement.Id }, _mapper.Map(fieldMeasurement));
            }

            catch (DataStoreException e)
            {
                _logger.LogError(e.Message, e, apiModel);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, FieldMeasurementFormApiModel apiModel)
        {
            try
            {
                FieldMeasurement fieldMeasurement = await _repository.GetByIdAsync(id);

                if (fieldMeasurement == null)
                {
                    return NotFound();
                }

                _mapper.Map(fieldMeasurement, apiModel);

                await _repository.UpdateAsync(fieldMeasurement);

                return Ok();
            }

            catch (DataStoreException e)
            {
                _logger.LogError(e.Message, e, apiModel);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}/{userId}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id, string userId)
        {
            try
            {
                FieldMeasurement fieldMeasurement = await _repository.GetByIdAsync(id);

                if (fieldMeasurement == null)
                {
                    return NotFound();
                }

                fieldMeasurement.ChangeStatus(userId);

                await _repository.UpdateAsync(fieldMeasurement);

                return Ok();
            }

            catch (DataStoreException e)
            {
                _logger.LogError(e.Message, e, id);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                FieldMeasurement fieldMeasurement = await _repository.GetByIdAsync(id);

                if (fieldMeasurement == null)
                {
                    return NotFound();
                }

                await _repository.DeleteAsync(fieldMeasurement);

                return Ok(id);
            }

            catch (DataStoreException e)
            {
                _logger.LogError(e.Message, e, id);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
